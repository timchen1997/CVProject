   M S B A M L   `   `   `  ����   	CVProject#    CVProject.Control.TabItemPlus   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources     CloseButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName��%�   &	        �� " ��.���  � �� �� " ��.R�� .+��� $
 text��$��10(�$��×��$��Center=�$��Center=� P�  � �� . . ��� $
	 text�� � ��
 ��������� " ��.���  � ��  	TextBrush# �  ��  � �� �� " ��
 � 	Resources
   HoverOn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HoverOff  
SelectedOn  SelectedOff��%�  &	       &	 o     &	 �     &	 P    �� .��U� $ 00:00:00X�$ HoverBorder��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� .��U� $ 00:00:00X�$ HoverBorder��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� .��U� $ 00:00:00X�$ SelectedBorder��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� .��U� $ 00:00:00X�$ SelectedBorder��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�.R��  �Name$
 grid��$��2,1,2,3q� � LayoutTransform V� .~���  �� ScaleX$ 1Q� �� ScaleY$ 1Q���  �� AngleX$ 0Q� �� AngleY$ 0Q���  �� Angle$ 0Q�T�  T� X$ 0Q� T� Y$ 0Q�.+���  ��Name$ border�� �� CornerRadius$ 2,2,2,2�� J� Opacity$	 0.5Q���Z� ����  �� EndPoint$ 	0.5,0.976&� �� 
StartPoint$ 	0.5,0.039&�.���  � Color$ 	#7F595959�� � Offset$ 0Q�� $ 	#19FFFFFF��$ 1Q��� $ SelectedBorder��$ 2,2,2,2��$ 0Q�  SelectedBackgroundBrush#���  ��Z� �� $ HoverBorder��$ 2,2,2,2��$ 0Q���Z� ���� $ 	0.5,0.976&�$ 	0.5,0.039&�.��� $ 	#7F595959��$ 0Q�� $ 	#19FFFFFF��$ 1Q��   � ColumnDefinitions  �� $��* ��� $��10 �.+��� ! ��Name$! ContentSite��$��0����. $��Header��$��Center=�$��6,1,6,1q�$��Center=��� $��	btn_Close��-   $��1��#��[   P�  �@��TabStripPlacement$
 Left=�. ��� $
	 grid�� �@�LayoutTransform V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $	 -90Q�T� $ 0Q�$ 0Q�P�  �@��TabStripPlacement$ Right=�. ��� $
	 grid�� �@�LayoutTransform V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 90Q�T� $ 0Q�$ 0Q�P�  �@��TabStripPlacement$ Bottom=�. ��� $	 ContentSite�� �@�LayoutTransform V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $	 180Q�T� $ 0Q�$ 0Q��� $
	 grid�� �@�LayoutTransform V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $	 180Q�T� $ 0Q�$ 0Q�]� " N� ExitActions" �� # ��Name$# HoverOff_BeginStoryboard��#��[ $ N� EnterActions$ �� #��[ % ]� 
Conditions% �� & �� Property& �@J�IsMouseOver' �� Value' . �� & �@��
IsSelected' .  P�  �@��
IsSelected . " �� $!# SelectedOff_BeginStoryboard��#��[ $ �� $ # SelectedOn_BeginStoryboard��#��[ . ���  �@K�ZIndex$	 100��]� % �� ( �� 
SourceName$
( grid��& �@J�IsMouseOver' . �� & �@��
IsSelected' . ./��� $	 border��# �   � ���� $	 border�� �@J�Opacity$	 0.9Q�P�  � {� .  . ���   DisabledForegroundBrush# �   � ���� $	 border��  DisabledBackgroundBrush# �   � ���� $
	 grid�� �@J�Opacity$	 0.3Q�) �� Triggers) P�  �@��
IsSelected . . ���  � �� ��  	 
BlackColor* �� Color#* � 	 .���� -   $
��root��$��Disabled=�$��Disabled=�.���� -   + ��Name$+ contentControl��.��� -   $��g��   
 	Imageview��%   &	
       V� .~��� T� .+��� -   , ��Name$, CurImage��$��Disabled=�#z�[
 - �� BitmapScalingMode$- NearestNeighbor=�. �� ClearTypeHint$. Enabled=��� -   $��
selectRect��
���   �$��2�����	#33000000$y�Hidden=�