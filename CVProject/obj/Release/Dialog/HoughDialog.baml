   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  "    CVProject.Dialog.HoughDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Hough Transform��$��161.364��$	��300�����	#FF363636 � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterScreen=�.��� .+�	� -    	�Name$ rbtnLine��$��Detect Line��$
��Left=�$��	10,10,0,0q�$	��Top=�	� -   $ 
rbtnCircle��$��Detect Circle��$
��Left=�$��	10,60,0,0q�$	��Top=��� -    ��Name$ label��$��	Threshold��$
��Left=�$��
140,10,0,0q�$	��Top=�%  Xceed.Wpf.Toolkit.IntegerUpDown  -   $��	threshold��$
��Left=�$��	200,8,0,0q�$	��Top=�$��66���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 50X�   Minimum$ 0X��� -   $ 
label_Copy��$��R Min��$
��Left=�$��
140,35,0,0q�$	��Top=�  -   $
��rmin��$
��Left=�$��
200,33,0,0q�$	��Top=�$��66��$	 100X�$ 1X��� -   $ label_Copy1��$��R Max��$
��Left=�$��
140,60,0,0q�$	��Top=�  -   $
��rmax��$
��Left=�$��
200,58,0,0q�$	��Top=�$��66��$	 200X�$ 1X��� -	    ��Name$ 	btnCancel��$��Cancel��$
��Left=�$��
190,98,0,0q�$	��Top=�$��76���� -
   $ btnOK��$��OK��$
��Left=�$��
109,98,0,0q�$	��Top=�$��76��